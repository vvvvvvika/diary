namespace Diary
{
    internal class Program
    {
        static private int y;
        static private int page = 0;
        static private bool canMove = true;

        static private List<Page> pages = new List<Page>();
        static void Main(string[] args)
        {
            Page page_1 = new();
            page_1.date = DateTime.Now;
            page_1.title_1 = "Купить продукты";
            page_1.title_2 = "Сделать практическую";
            page_1.description_1 = "молоко\nхлеб\nкотлеты\nогурцы";
            page_1.description_2 = "ис\nпианино\nчет еще";
            pages.Add(page_1);

            Page page_2 = new();
            page_2.date = DateTime.Now.AddDays(+1);
            page_2.title_1 = "Сделать суп";
            page_2.title_2 = "Погладить кота";
            page_2.description_1 = "огурцы\nморковь\nмясо\nварить 40 минут";
            page_2.description_2 = "в 18:00 погладить Барсика";
            pages.Add(page_2);

            Page page_3 = new();
            page_3.date = DateTime.Now.AddDays(+2);
            page_3.title_1 = "Погулять";
            page_3.title_2 = "Сделать дз";
            page_3.description_1 = "20:00\nМ. Сокольники";
            page_3.description_2 = "выучить историю на субботу";
            pages.Add(page_3);

            Page page_4 = new();
            page_4.date = DateTime.Now.AddDays(+3);
            page_4.title_1 = "Тут задание какое-то";
            page_4.title_2 = "И тут тоже";
            page_4.description_1 = "надо сделать\nда, надо";
            page_4.description_2 = "в 18:00 сделать задание которое выше";
            pages.Add(page_4);

            Page page_5 = new();
            page_5.date = DateTime.Now.AddDays(+5);
            page_5.title_1 = "Тут задание какое-то";
            page_5.title_2 = "И тут тоже";
            page_5.description_1 = "надо сделать\nда, надо";
            page_5.description_2 = "в 18:00 сделать задание которое выше";
            pages.Add(page_5);

            SelectDate(0);

            moveArrow();
        }

        static private void SelectDate(int page)
        {
            Console.Clear();
            int count = 0;
            foreach (Page p in pages)
            {
                if (count == page)
                {
                    Console.WriteLine("  " + p.date);
                    Console.WriteLine("  " + p.title_1);
                    Console.WriteLine("  " + p.title_2);
                }
                count++;
            }
        }
        static private void ShowDescription(int y, int page)
        {
            Console.Clear();
            int count = 0;
            foreach (Page p in pages)
            {
                if (count == page && y == 1)
                {
                    Console.WriteLine(p.title_1);
                    Console.WriteLine("---------------");
                    Console.WriteLine("Описание: " + p.description_1);
                    Console.WriteLine("Дата: " + p.date);
                }
                else if (count == page && y == 2)
                {
                    Console.WriteLine(p.title_2);
                    Console.WriteLine("---------------");
                    Console.WriteLine("Описание: " + p.description_2);
                    Console.WriteLine("Дата: " + p.date);
                }
                count++;
            }
            while (canMove == false)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.Escape:
                        canMove = true;
                        SelectDate(page);
                        moveArrow();
                        break;
                }
            }
        }

        static private void moveArrow()
        {
            while (canMove == true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (y > 1)
                        {
                            Console.SetCursorPosition(0, y);
                            Console.WriteLine("  ");
                            y--;
                            Console.SetCursorPosition(0, y);
                            Console.WriteLine("->");
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (y < 2)
                        {
                            Console.SetCursorPosition(0, y);
                            Console.WriteLine("  ");
                            y++;
                            Console.SetCursorPosition(0, y);
                            Console.WriteLine("->");
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (page < pages.Count - 1)
                        {
                            page++;
                            SelectDate(page);
                        };
                        break;
                    case ConsoleKey.LeftArrow:
                        if (page > 0)
                        {
                            page--;
                            SelectDate(page);
                        };
                        break;
                    case ConsoleKey.Enter:
                        canMove = false;
                        ShowDescription(y, page);
                        break;
                }
            }
        }

    }

    internal class Page
    {
        public DateTime date;
        public string title_1;
        public string title_2;
        public string description_1;
        public string description_2;
    }
}