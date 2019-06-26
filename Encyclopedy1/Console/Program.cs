using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Encyclopedy
{
    public class Program
    {
        private string Title { get; set; }

        public bool BreadcrumbHeader { get; private set; }

        private Page CurrentPage
        {
            get
            {
                return this.History.Any<Page>() ? this.History.Peek() : (Page)null;
            }
        }

        private Dictionary<Type, Page> Pages { get; set; }

        public Stack<Page> History { get; private set; }

        public bool NavigationEnabled
        {
            get
            {
                return this.History.Count > 1;
            }
        }

        public Program(string title, bool breadcrumbHeader)
        {
            this.Title = title;
            this.Pages = new Dictionary<Type, Page>();
            this.History = new Stack<Page>();
            this.BreadcrumbHeader = breadcrumbHeader;
        }

        public virtual void Run()
        {
            try
            {
                Console.Title = this.Title;
                this.CurrentPage.Display();
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
            Type type = page.GetType();
            if (this.Pages.ContainsKey(type))
                this.Pages[type] = page;
            else
                this.Pages.Add(type, page);
        }

        public void NavigateHome()
        {
            while (this.History.Count > 1)
                this.History.Pop();
            Console.Clear();
            this.CurrentPage.Display();
        }

        public T SetPage<T>() where T : Page
        {
            Type key = typeof(T);
            if (this.CurrentPage != null && this.CurrentPage.GetType() == key)
                return this.CurrentPage as T;
            Page page;
            if (!this.Pages.TryGetValue(key, out page))
                throw new KeyNotFoundException("The given page was not present in the program");
            this.History.Push(page);
            return this.CurrentPage as T;
        }

        public T NavigateTo<T>() where T : Page
        {
            this.SetPage<T>();
            Console.Clear();
            this.CurrentPage.Display();
            return this.CurrentPage as T;
        }

        public Page NavigateBack()
        {
            this.History.Pop();
            Console.Clear();
            this.CurrentPage.Display();
            return this.CurrentPage;
        }

    }
}