using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Encyclopedy
{
    public class Program
    {
        private string Title { get; set; }

        private Page CurrentPage => History.Any() ? History.Peek() : null;

        private Dictionary<Type, Page> Pages { get; set; }

        public Stack<Page> History { get; private set; }

        public bool NavigationEnabled => History.Count > 1;

        public Program(string title)
        {
            Title = title;
            Pages = new Dictionary<Type, Page>();
            History = new Stack<Page>();
        }

        public virtual void Run()
        {
            try
            {
                Console.Title = Title;
                CurrentPage.Display();
            }
            catch (Exception ex)
            {
                Output.WriteLine(ConsoleColor.Red, ex.ToString());
            }
            finally
            {
                if (Debugger.IsAttached)
                    Input.ReadString("Press [Enter] to exit");
            }
        }

        public void AddPage(Page page)
        {
            var type = page.GetType();
            if (Pages.ContainsKey(type))
                Pages[type] = page;
            else
                Pages.Add(type, page);
        }

        public void NavigateHome()
        {
            while (History.Count > 1)
                History.Pop();
            Console.Clear();
            CurrentPage.Display();
        }

        public T SetPage<T>() where T : Page
        {
            var key = typeof(T);
            if (CurrentPage != null && CurrentPage.GetType() == key)
                return CurrentPage as T;
            Page page;
            if (!Pages.TryGetValue(key, out page))
                throw new KeyNotFoundException("The given page was not present in the program");
            History.Push(page);
            return CurrentPage as T;
        }

        public T NavigateTo<T>() where T : Page
        {
            SetPage<T>();
            Console.Clear();
            CurrentPage.Display();
            return CurrentPage as T;
        }
        public T NavigateTo<T>(Article article) where T : Page
        {
            SetPage<T>();
            Console.Clear();
            CurrentPage.Display(article);
            return CurrentPage as T;
        }

        public Page NavigateBack()
        {
            History.Pop();
            Console.Clear();
            CurrentPage.Display();
            return CurrentPage;
        }
    }
}