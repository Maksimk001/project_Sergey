using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Play
{
    public partial class QuestionPage : Page
    {
        private int currentQuestionIndex = 0;

        private List<Question> questions = new List<Question>
        {
           new Question("Какое событие стало началом правления династии Романовых в России?",  "В конце XVI — начале XVII века Россия переживала период смуты, который был вызван политической нестабильностью, экономическими трудностями и внешними угрозами. Этот кризис кульминировал в борьбе за власть и конфликте между различными претендентами на трон. В 1613 году на Земском соборе была избрана новая династия, которая должна была восстановить порядок в стране.", new List<string> { "Появление Лжедмитрия I", "Земский собор", "Освобождение Москвы от польских интервентов", "Установление самодержавия" }, "Земский собор"),
            new Question("Какой из следующих шагов был предпринят Петром I для создания регулярной армии?",  "Петр I, известный как Петр Великий, стал одним из самых значительных правителей в истории России. Его реформы охватывали все сферы жизни — от армии до культуры. Он стремился модернизировать страну, опираясь на западные образцы, и это привело к созданию нового облика российского государства.", new List<string> { "Введение рекрутской повинности", "Установление системы выборного самоуправления", "Создание военных округов", "Проведение военной реформы 1716 года" }, "Введение рекрутской повинности"),
            new Question("Какой указ подписал Александр II, отменяющий крепостное право в России?",  "В XIX веке Россия столкнулась с различными социальными и политическими движениями, которые начали набирать силу на фоне экономических изменений и роста общественного сознания. Отмена крепостного права в 1861 году стала одним из самых значительных событий этого периода, открывшим новые возможности для крестьян и вызвавшим множество последствий для всей страны.", new List<string> { "Указ о создании крестьянских обществ", "Указ о праве на землю", "Указ о земской реформе", "Указ о свободе крестьян" }, "Указ о свободе крестьян"),
            new Question("Какое событие стало непосредственным толчком к Февральской революции 1917 года?",  "Первая мировая война стала серьезным испытанием для России, которое выявило слабости царского режима и привело к массовым протестам. В результате войны страна столкнулась с большими потерями, экономическим кризисом и социальной напряженностью. Эти факторы способствовали возникновению революционных настроений, которые в конечном итоге привели к свержению монархии.", new List<string> { "Начало Брусиловского прорыва", "Объявление войны Германии", "Забастовки рабочих в Петрограде", "Расстрел демонстрации в 1905 году" }, "Забастовки рабочих в Петрограде"),
            new Question("Какой мирный договор был подписан между Советской Россией и Польшей в 1921 году, завершивший гражданскую войну?",  "Гражданская война в России (1917-1922) стала результатом глубоких политических и социальных изменений, произошедших после Октябрьской революции. Конфликт между красными (большевиками) и белыми (антибольшевистскими силами) привел к значительным разрушениям и потерям. В результате войны была установлена советская власть, но она не была единственной силой, стремившейся к власти.", new List<string> { "Брестский мир", "Рижский мир", "Тартуский мир", "Договор о дружбе и границе" }, "Рижский мир"),
        };

        public QuestionPage()
        {
            InitializeComponent(); 
            LoadQuestion();

        }

        private void LoadQuestion()
        {
            if (currentQuestionIndex < questions.Count)
            {
                var question = questions[currentQuestionIndex];
                QuestionTextBlock.Text = question.Text;
                IntroTextBox.Text = question.IntroText; // Устанавливаем текст предисловия
                AnswersPanel.Children.Clear();

                foreach (var answer in question.Answers)
                {
                    Button answerButton = new Button
                    {
                        Content = answer,
                        Style = (Style)FindResource("AnswerButtonStyle") // Применяем стиль
                    };
                    answerButton.Click += AnswerButton_Click;
                    AnswersPanel.Children.Add(answerButton);
                }
            }
            else
            {
                MessageBox.Show($"Игра окончена! Ваш счет: {GameManager.Instance.CurrentScore}");
                GameManager.Instance.UpdateLeaderboard();

                Perehod perehodPage = new Perehod();
                MaintwoFrame.Navigate(perehodPage);
            }
        }

        private void AnswerButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button.Content.ToString() == questions[currentQuestionIndex].CorrectAnswer)
            {
                GameManager.Instance.AddScore(50); // Добавляем баллы за правильный ответ
                currentQuestionIndex++;
                LoadQuestion();
            }
            else
            {
                MessageBox.Show("Неправильный ответ! Попробуйте еще раз.");
                // Логика для повторного ответа или возврата к первому вопросу
                currentQuestionIndex = Math.Max(0, currentQuestionIndex);
                LoadQuestion();
            }
        }


        private void NazadMeny_Click(object sender, RoutedEventArgs e)
         {
            WorldPage worldPage = new WorldPage();
            MaintwoFrame.Navigate(worldPage);
         }

    }

    public class Question
    {
        public string Text { get; set; }
        public string IntroText { get; set; } // Предисловие
        public List<string> Answers { get; set; }
        public string CorrectAnswer { get; set; }

        public Question(string text, string introText, List<string> answers, string correctAnswer)
        {
            Text = text;
            IntroText = introText; // Инициализация предисловия
            Answers = answers;
            CorrectAnswer = correctAnswer;
        }
    }
}
