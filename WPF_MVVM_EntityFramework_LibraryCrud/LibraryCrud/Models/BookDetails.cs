namespace LibraryCrud.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BookDetails:BaseModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string author;
        public string Author
        {
            get { return author; }
            set
            {
                author = value;
                OnPropertyChanged(nameof(Author));
            }
        }

        private string publisher;
        public string Publisher
        {
            get { return publisher; }
            set
            {
                publisher = value;
                OnPropertyChanged(nameof(Publisher));
            }
        }

        private Nullable<short> page;
        public Nullable<short> Page
        {
            get { return page; }
            set
            {
                page = value;
                OnPropertyChanged(nameof(Page));
            }
        }
    }
}
