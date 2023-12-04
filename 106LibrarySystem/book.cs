using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace LibraryDatabase
{
    public class Book : INotifyPropertyChanged
    {
        public int _availability;
        public string _name;
        public string _author;
        public string _imagePath;

        public int Id { get; set; }
        public string Name { get; set; }
        public string name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(name));
                }
            }
        }

        public string author
        {
            get { return _author; }
            set
            {
                if (_author != value)
                {
                    _author = value;
                    OnPropertyChanged(nameof(author));
                }
            }
        }

        public string genre { get; set; }

        public int availability
        {
            get { return _availability; }
            set
            {
                if (_availability != value)
                {
                    _availability = value;
                    OnPropertyChanged(nameof(availability));
                    OnPropertyChanged(nameof(DisplayAvailability));
                    OnPropertyChanged(nameof(AvailabilityColor));
                }
            }
        }

        public string language { get; set; }
        public int pageNum { get; set; }
        public int date { get; set; }

        public string ImagePath
        {
            get { return _imagePath; }
            set
            {
                if (_imagePath != value)
                {
                    _imagePath = value;
                    OnPropertyChanged(nameof(ImagePath));
                }
            }
        }
        public string description { get; set; }

        public string DisplayAvailability
        {
            get { return availability > 0 ? "Available" : "Unavailable"; }
        }

        public string AvailabilityColor
        {
            get { return availability > 0 ? "Green" : "Red"; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public DateTime? returnDate;

        public int loanID { get; set; }
        public int bookID { get; set; }
        public int userID { get; set; }
        public DateTime loanDate { get; set; }
        public DateTime dueDate { get; set; }
        public string loanStatus { get; set; }
    }
}