using System;

namespace Calc
{
    public class DailyRows
    {
        public int Id { get; set; }
        public DateTime Dates { get; set; }
        public float Amounts { get; set; }
        public double Total { get; set; }

        public override string ToString()
        {
            return string.Format("Id:{0} dates:{1} amounts:{2} total:{3}", this.Id.ToString(), this.Dates.Date, this.Amounts, this.Total);
        }
    }
}
