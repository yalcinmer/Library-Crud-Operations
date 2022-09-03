using LibraryCrud.Commands;
using LibraryCrud.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryCrud.ViewModels
{
    public class LibraryViewModel:BaseModel
    {
        LibraryEntities libraryEntities;
        private ObservableCollection<BookDetails> books;
        private BookDetails selectedBook;
        private BookDetails book = new BookDetails();
        private ICommand deleteCommand;
        private ICommand updateCommand;
        private ICommand addBookCommand;
        private ICommand updateBookCommand;

        public LibraryViewModel()
        {
            libraryEntities = new LibraryEntities();
            ListOfBooks = new ObservableCollection<BookDetails>(libraryEntities.BookDetails);
            
        }

        public ObservableCollection<BookDetails> ListOfBooks
        {
            get { return books; }
            set
            {
                books = value;
                OnPropertyChanged(nameof(ListOfBooks));
            }
        }
        public BookDetails SelectedBook
        {
            get { return selectedBook; }
            set
            {
                selectedBook = value;
                OnPropertyChanged(nameof(SelectedBook));
            }
        }

        public BookDetails Book
        {
            get { return book; }
            set
            {
                book = value;
                OnPropertyChanged(nameof(Book));
            }
        }

        private void Delete(object obj)
        {
            var temp = obj as BookDetails;
            libraryEntities.BookDetails.Remove(temp);
            libraryEntities.SaveChanges();
            ListOfBooks.Remove(temp);
        }

        public ICommand DeleteCommand
        {
            get 
            { 
                if(deleteCommand == null)
                {
                    deleteCommand = new RelayCommand(Delete, (s) => true);
                }
                return deleteCommand;
            }
        }

        public ICommand UpdateCommand
        {
            get
            {
                if(updateCommand == null)
                {
                    updateCommand = new RelayCommand(Update, (s) => true);
                }
                return updateCommand;
            }
        }

        private void Update(object obj)
        {
            SelectedBook = obj as BookDetails;
        }

        public ICommand AddBookCommand
        {
            get
            {
                if(addBookCommand == null)
                {
                    addBookCommand = new RelayCommand(AddBook, CanAddBook, false);
                }
                return addBookCommand;
            }
        }

        private void AddBook(object obj)
        {
            Book.Id = libraryEntities.BookDetails.Count()+1;
            libraryEntities.BookDetails.Add(Book);
            libraryEntities.SaveChanges();
            ListOfBooks.Add(Book);
            Book = new BookDetails();
        }

        private bool CanAddBook(object obj)
        {
            if (string.IsNullOrEmpty(Book.Name) || string.IsNullOrEmpty(Book.Author) || string.IsNullOrEmpty(Book.Publisher) || string.IsNullOrEmpty(Book.Page.ToString()))
                return false;
            else return true;
        }


        public ICommand UpdateBookCommand
        {
            get
            {
                if(updateBookCommand == null)
                {
                    updateBookCommand = new RelayCommand(UpdateBook, (s) => true);
                }
                return updateBookCommand;
            }
        }

        public void UpdateBook(object obj)
        {
            libraryEntities.SaveChanges();
            SelectedBook = new BookDetails();
        }

    }
}
