using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace LibraryDatabase
{
    public class Book : INotifyPropertyChanged
    {
        private int _availability;
        private string _name;
        private string _author;
        private string _imagePath;

        public int Id { get; set; }

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
    }
}

