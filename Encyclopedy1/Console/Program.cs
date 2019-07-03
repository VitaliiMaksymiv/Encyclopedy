using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Encyclopedy1.Models;

namespace Encyclopedy1.Console
{
    public class Program
    {
        private readonly string _title;

        private readonly Dictionary<Type, Page> _pages;

        private Page CurrentPage => History.Any() ? History.Peek() : null;

        public Program(string title)
        {
            _title = title;
            _pages = new Dictionary<Type, Page>();
            History = new Stack<Page>();
        }

        public Stack<Page> History { get; }

        public bool IsNavigationEnabled => History.Count > 1;

        public void Run()
        {
            try
            {
                System.Console.Title = _title;
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
            if (_pages.ContainsKey(type))
                _pages[type] = page;
            else
                _pages.Add(type, page);
        }

        public void NavigateHome()
        {
            while (History.Count > 1)
                History.Pop();
            System.Console.Clear();
            CurrentPage.Display();
        }

        public T SetPage<T>() where T : Page
        {
            var key = typeof(T);
            if (CurrentPage != null && CurrentPage.GetType() == key)
                return CurrentPage as T;
            if (!_pages.TryGetValue(key, out var page))
                throw new KeyNotFoundException("The given page was not present in the program");
            History.Push(page);
            return CurrentPage as T;
        }

        public T NavigateTo<T>() where T : Page
        {
            SetPage<T>();
            System.Console.Clear();
            CurrentPage.Display();
            return CurrentPage as T;
        }
        public T NavigateTo<T>(Article article) where T : Page
        {
            SetPage<T>();
            System.Console.Clear();
            CurrentPage.Display(article);
            return CurrentPage as T;
        }

        public Page NavigateBack()
        {
            History.Pop();
            System.Console.Clear();
            CurrentPage.Display();
            return CurrentPage;
        }
    }
}