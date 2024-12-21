using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Play
{

    [System.Serializable]
    public class LeaderboardEntry
    {
        public string PlayerName { get; set; }
        public int Score { get; set; }
    }

    internal class GameManager
    {
        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameManager();
                    _instance.LoadLeaderboard(); // Загружаем таблицу лидеров при создании экземпляра
                }
                return _instance;
            }
        }

        public string PlayerName { get; set; }
        public int CurrentScore { get; private set; } // Свойство для хранения текущих очков

        private List<LeaderboardEntry> leaderboard = new List<LeaderboardEntry>();

        public void AddScore(int points)
        {
            CurrentScore += points; // Добавляем очки к текущему счету
            UpdateLeaderboard(); // Обновляем таблицу лидеров после добавления очков
            SaveLeaderboard(); // Сохраняем таблицу лидеров после обновления
        }

        public void UpdateLeaderboard()
        {
            var existingEntry = leaderboard.FirstOrDefault(x => x.PlayerName == PlayerName);
            if (existingEntry != null)
            {
                existingEntry.Score = CurrentScore; // Обновляем очки существующего игрока
            }
            else
            {
                leaderboard.Add(new LeaderboardEntry { PlayerName = this.PlayerName, Score = this.CurrentScore }); // Добавляем нового игрока
            }

            leaderboard = leaderboard.OrderByDescending(x => x.Score).ToList(); // Сортируем по очкам
        }

        public List<LeaderboardEntry> GetLeaderboard()
        {
            return leaderboard; // Возвращаем список лидеров
        }

        public void ResetGame()
        {
            CurrentScore = 0; // Сбрасываем текущий счет
        }

        private void SaveLeaderboard()
        {
            using (FileStream stream = new FileStream("leaderboard.dat", FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, leaderboard);
            }
        }

        private void LoadLeaderboard()
        {
            if (File.Exists("leaderboard.dat"))
            {
                using (FileStream stream = new FileStream("leaderboard.dat", FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    leaderboard = (List<LeaderboardEntry>)formatter.Deserialize(stream);
                }
            }
        }
    }
}

