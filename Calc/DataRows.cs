using System;

namespace Calc
{
    public class DataRows
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int DaysInPeriod { get; set; }
        public float AmountPrDay { get; set; }

        public DataRows(int id, float amount, DateTime fromDate, DateTime toDate)
        {
            Id = id;
            Amount = amount;
            FromDate = fromDate;
            ToDate = toDate;

            DaysInPeriod = (int)(toDate - fromDate).TotalDays + 1;
            AmountPrDay = amount / this.DaysInPeriod;
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5}", this.Id.ToString(), this.Amount, this.FromDate.Date, this.ToDate.Date, this.DaysInPeriod.ToString(), this.AmountPrDay);
        }
    }
}
