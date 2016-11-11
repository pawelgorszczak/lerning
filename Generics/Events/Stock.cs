using System;

namespace Generics.Events
{
    public class Stock
    {
        private readonly string _symbol;
        private decimal _price;

        public decimal Price
        {
            get { return _price; }
            set
            {
                if (_price == value) return;
                _price = value;
                OnPriceChanged(EventArgs.Empty);
            }
        }

        public Stock(string symbol)
        {
            _symbol = symbol;
        }

        public event EventHandler PriceChanged;
        protected virtual void OnPriceChanged(EventArgs e)
        {
            if (PriceChanged != null) PriceChanged.Invoke(this,e);
        }

    }
}