using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calc
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<Data> data = new List<Data>();
            InitializeData(data);
            List<DataRows> nd = NormalizeData(data);
            List<List<DailyRows>> dr = CreateDataPrDay(nd);

            foreach (List<DailyRows> period in dr)
            {
                DateTime fromDate = period.Min(p => p.Dates);
                DateTime todate = period.Max(p => p.Dates);
                Double total = period.Max(p => p.Total);
                
                Debug.WriteLine(string.Format("Period [{0} - {1}] Total: {2}", fromDate.Date, todate.Date, total));

                foreach (var dailyRows in period)
                {
                    //Debug.WriteLine(string.Format("{0};{1};{2};{3}", dailyRows.Id, dailyRows.Dates.Date.ToString("dd-MM-yyyy"), dailyRows.Amounts, (int)dailyRows.Total));
                    Debug.WriteLine(string.Format("{0}\t{1}",  dailyRows.Dates.Date.ToString("dd-MM-yyyy"), (int)dailyRows.Total));
                }
            }
        }

        private List<List<DailyRows>> CreateDataPrDay(List<DataRows> nd)
        {
            DateTime currentDate = nd.OrderBy(p => p.FromDate).First().FromDate;
            Double total = 0;

            DateTime previousdate = currentDate;
            int maxGabDays = 25;

            List<DailyRows> dailyRows = new List<DailyRows>();
            List<List<DailyRows>> periods = new List<List<DailyRows>>();

            foreach (var item in nd.OrderBy(p => p.FromDate))
            {
                if (item.FromDate > previousdate.AddDays(maxGabDays))
                {
                    total = 0;
                    periods.Add(dailyRows);
                    dailyRows = new List<DailyRows>();
                    Debug.WriteLine(string.Format("resetting total at: {0}", item.FromDate.ToShortDateString()));
                }

                for (int i = 0; i < (item.ToDate - item.FromDate).TotalDays + 1; i++)
                {
                    total += item.AmountPrDay;
                    dailyRows.Add(new DailyRows() { Id = item.Id, Dates = item.FromDate.AddDays(i), Amounts = item.AmountPrDay, Total = total });
                }

                previousdate = item.FromDate;
            }

            if (dailyRows.Count > 0)
            {
                periods.Add(dailyRows);
            }

            return periods;

        }

        private List<DataRows> NormalizeData(List<Data> data)
        {
            // align the from and to rows into one row
            List<DataRows> rd = new List<DataRows>();
            foreach (var item in data.Skip(1))
            {
                var p0 = data.Select(p => p.Date.Date);
                var p1 = p0.Where<DateTime>(d => d.Date < item.Date.Date);
                if (p1.Any())
                {
                    var p2 = p1.OrderByDescending(o => o.Date);
                    DateTime fromDate = p2.First();

                    rd.Add(new DataRows(item.Id, item.Amount, fromDate, item.Date.AddDays(-1)));
                }
            }

            return rd;

        }

        private static void InitializeData(List<Data> data)
        {
            int i = 1;
            data.Add(new Data() { Id = i++, Amount = 324, Date = new DateTime(2011, 09, 10) });
            data.Add(new Data() { Id = i++, Amount = 360, Date = new DateTime(2011, 09, 22) });
            data.Add(new Data() { Id = i++, Amount = 324, Date = new DateTime(2011, 10, 04) });
            data.Add(new Data() { Id = i++, Amount = 324, Date = new DateTime(2011, 10, 14) });
            data.Add(new Data() { Id = i++, Amount = 324, Date = new DateTime(2011, 10, 21) });
            data.Add(new Data() { Id = i++, Amount = 288, Date = new DateTime(2011, 11, 06) });
            data.Add(new Data() { Id = i++, Amount = 304, Date = new DateTime(2011, 11, 13) });
            data.Add(new Data() { Id = i++, Amount = 288, Date = new DateTime(2011, 11, 19) });
            data.Add(new Data() { Id = i++, Amount = 304, Date = new DateTime(2011, 11, 26) });
            data.Add(new Data() { Id = i++, Amount = 288, Date = new DateTime(2011, 12, 02) });
            data.Add(new Data() { Id = i++, Amount = 272, Date = new DateTime(2011, 12, 07) });
            data.Add(new Data() { Id = i++, Amount = 160, Date = new DateTime(2011, 12, 12) });
            data.Add(new Data() { Id = i++, Amount = 240, Date = new DateTime(2011, 12, 14) });
            data.Add(new Data() { Id = i++, Amount = 272, Date = new DateTime(2011, 12, 19) });
            data.Add(new Data() { Id = i++, Amount = 288, Date = new DateTime(2011, 12, 24) });
            data.Add(new Data() { Id = i++, Amount = 288, Date = new DateTime(2011, 12, 29) });
            data.Add(new Data() { Id = i++, Amount = 272, Date = new DateTime(2012, 01, 03) });
            data.Add(new Data() { Id = i++, Amount = 304, Date = new DateTime(2012, 01, 08) });
            data.Add(new Data() { Id = i++, Amount = 352, Date = new DateTime(2012, 01, 13) });
            data.Add(new Data() { Id = i++, Amount = 240, Date = new DateTime(2012, 01, 18) });
            data.Add(new Data() { Id = i++, Amount = 288, Date = new DateTime(2012, 01, 23) });
            data.Add(new Data() { Id = i++, Amount = 240, Date = new DateTime(2012, 01, 27) });
            data.Add(new Data() { Id = i++, Amount = 128, Date = new DateTime(2012, 01, 29) });
            data.Add(new Data() { Id = i++, Amount = 288, Date = new DateTime(2012, 02, 02) });
            data.Add(new Data() { Id = i++, Amount = 288, Date = new DateTime(2012, 02, 06) });
            data.Add(new Data() { Id = i++, Amount = 272, Date = new DateTime(2012, 02, 09) });
            data.Add(new Data() { Id = i++, Amount = 128, Date = new DateTime(2012, 02, 11) });
            data.Add(new Data() { Id = i++, Amount = 272, Date = new DateTime(2012, 02, 14) });
            data.Add(new Data() { Id = i++, Amount = 256, Date = new DateTime(2012, 02, 18) });
            data.Add(new Data() { Id = i++, Amount = 240, Date = new DateTime(2012, 02, 22) });
            data.Add(new Data() { Id = i++, Amount = 112, Date = new DateTime(2012, 02, 25) });
            data.Add(new Data() { Id = i++, Amount = 224, Date = new DateTime(2012, 02, 29) });
            data.Add(new Data() { Id = i++, Amount = 224, Date = new DateTime(2012, 03, 05) });
            data.Add(new Data() { Id = i++, Amount = 256, Date = new DateTime(2012, 03, 14) });
            data.Add(new Data() { Id = i++, Amount = 256, Date = new DateTime(2012, 03, 20) });
            data.Add(new Data() { Id = i++, Amount = 224, Date = new DateTime(2012, 03, 26) });
            data.Add(new Data() { Id = i++, Amount = 224, Date = new DateTime(2012, 04, 01) });
            data.Add(new Data() { Id = i++, Amount = 224, Date = new DateTime(2012, 04, 06) });
            data.Add(new Data() { Id = i++, Amount = 240, Date = new DateTime(2012, 04, 10) });
            data.Add(new Data() { Id = i++, Amount = 256, Date = new DateTime(2012, 04, 17) });
            data.Add(new Data() { Id = i++, Amount = 240, Date = new DateTime(2012, 04, 24) });
            data.Add(new Data() { Id = i++, Amount = 240, Date = new DateTime(2012, 05, 02) });
            data.Add(new Data() { Id = i++, Amount = 272, Date = new DateTime(2012, 05, 12) });
            data.Add(new Data() { Id = i++, Amount = 256, Date = new DateTime(2012, 05, 24) });
            data.Add(new Data() { Id = i++, Amount = 256, Date = new DateTime(2012, 06, 06) });
            data.Add(new Data() { Id = i++, Amount = 160, Date = new DateTime(2012, 06, 19) });
            data.Add(new Data() { Id = i++, Amount = 80, Date = new DateTime(2012, 07, 02) });
            data.Add(new Data() { Id = i++, Amount = 208, Date = new DateTime(2012, 08, 28) });
            data.Add(new Data() { Id = i++, Amount = 256, Date = new DateTime(2012, 09, 08) });
            data.Add(new Data() { Id = i++, Amount = 272, Date = new DateTime(2012, 09, 22) });
            data.Add(new Data() { Id = i++, Amount = 224, Date = new DateTime(2012, 09, 30) });
            data.Add(new Data() { Id = i++, Amount = 288, Date = new DateTime(2012, 10, 08) });
            data.Add(new Data() { Id = i++, Amount = 240, Date = new DateTime(2012, 10, 15) });
            data.Add(new Data() { Id = i++, Amount = 208, Date = new DateTime(2012, 10, 21) });
            data.Add(new Data() { Id = i++, Amount = 240, Date = new DateTime(2012, 10, 27) });
            data.Add(new Data() { Id = i++, Amount = 256, Date = new DateTime(2012, 11, 01) });
            data.Add(new Data() { Id = i++, Amount = 256, Date = new DateTime(2012, 11, 07) });
            data.Add(new Data() { Id = i++, Amount = 256, Date = new DateTime(2012, 11, 13) });
            data.Add(new Data() { Id = i++, Amount = 320, Date = new DateTime(2012, 11, 20) });
            data.Add(new Data() { Id = i++, Amount = 240, Date = new DateTime(2012, 11, 25) });
            data.Add(new Data() { Id = i++, Amount = 288, Date = new DateTime(2012, 12, 01) });
            data.Add(new Data() { Id = i++, Amount = 256, Date = new DateTime(2012, 12, 05) });
            data.Add(new Data() { Id = i++, Amount = 208, Date = new DateTime(2012, 12, 09) });
            data.Add(new Data() { Id = i++, Amount = 288, Date = new DateTime(2012, 12, 13) });
            data.Add(new Data() { Id = i++, Amount = 288, Date = new DateTime(2012, 12, 18) });
            data.Add(new Data() { Id = i++, Amount = 288, Date = new DateTime(2012, 12, 23) });
            data.Add(new Data() { Id = i++, Amount = 288, Date = new DateTime(2012, 12, 28) });
            data.Add(new Data() { Id = i++, Amount = 272, Date = new DateTime(2013, 01, 02) });
            data.Add(new Data() { Id = i++, Amount = 272, Date = new DateTime(2013, 01, 07) });
            data.Add(new Data() { Id = i++, Amount = 256, Date = new DateTime(2013, 01, 12) });
            data.Add(new Data() { Id = i++, Amount = 272, Date = new DateTime(2013, 01, 16) });
            data.Add(new Data() { Id = i++, Amount = 256, Date = new DateTime(2013, 01, 20) });
            data.Add(new Data() { Id = i++, Amount = 304, Date = new DateTime(2013, 01, 25) });
            data.Add(new Data() { Id = i++, Amount = 240, Date = new DateTime(2013, 01, 28) });
            data.Add(new Data() { Id = i++, Amount = 272, Date = new DateTime(2013, 02, 02) });
            data.Add(new Data() { Id = i++, Amount = 272, Date = new DateTime(2013, 02, 06) });
            data.Add(new Data() { Id = i++, Amount = 272, Date = new DateTime(2013, 02, 11) });
            data.Add(new Data() { Id = i++, Amount = 208, Date = new DateTime(2013, 02, 14) });
            data.Add(new Data() { Id = i++, Amount = 240, Date = new DateTime(2013, 02, 18) });

            data.Add(new Data() { Id = i++, Amount = 270, Date = new DateTime(2013, 12, 03) });
            data.Add(new Data() { Id = i++, Amount = 210, Date = new DateTime(2013, 12, 07) });
            data.Add(new Data() { Id = i++, Amount = 240, Date = new DateTime(2013, 12, 12) });
            data.Add(new Data() { Id = i++, Amount = 270, Date = new DateTime(2013, 12, 17) });
            data.Add(new Data() { Id = i++, Amount = 270, Date = new DateTime(2013, 12, 23) });
            data.Add(new Data() { Id = i++, Amount = 255, Date = new DateTime(2013, 12, 28) });
            data.Add(new Data() { Id = i++, Amount = 270, Date = new DateTime(2014, 01, 02) });
            data.Add(new Data() { Id = i++, Amount = 270, Date = new DateTime(2014, 01, 07) });
            data.Add(new Data() { Id = i++, Amount = 225, Date = new DateTime(2014, 01, 12) });
            data.Add(new Data() { Id = i++, Amount = 270, Date = new DateTime(2014, 01, 17) });
            data.Add(new Data() { Id = i++, Amount = 240, Date = new DateTime(2014, 01, 21) });
            data.Add(new Data() { Id = i++, Amount = 255, Date = new DateTime(2014, 01, 25) });
            data.Add(new Data() { Id = i++, Amount = 240, Date = new DateTime(2014, 01, 28) });
            data.Add(new Data() { Id = i++, Amount = 255, Date = new DateTime(2014, 02, 01) });
            data.Add(new Data() { Id = i++, Amount = 270, Date = new DateTime(2014, 02, 06) });
            data.Add(new Data() { Id = i++, Amount = 270, Date = new DateTime(2014, 02, 11) });
            data.Add(new Data() { Id = i++, Amount = 255, Date = new DateTime(2014, 02, 16) });
            data.Add(new Data() { Id = i++, Amount = 255, Date = new DateTime(2014, 02, 21) });
            data.Add(new Data() { Id = i++, Amount = 225, Date = new DateTime(2014, 02, 26) });
            data.Add(new Data() { Id = i++, Amount = 270, Date = new DateTime(2014, 03, 04) });
            data.Add(new Data() { Id = i++, Amount = 240, Date = new DateTime(2014, 03, 09) });
            data.Add(new Data() { Id = i++, Amount = 270, Date = new DateTime(2014, 03, 16) });
            data.Add(new Data() { Id = i++, Amount = 300, Date = new DateTime(2014, 03, 23) });
            data.Add(new Data() { Id = i++, Amount = 300, Date = new DateTime(2014, 03, 30) });
            data.Add(new Data() { Id = i++, Amount = 285, Date = new DateTime(2014, 04, 06) });
            data.Add(new Data() { Id = i++, Amount = 225, Date = new DateTime(2014, 04, 12) });
            data.Add(new Data() { Id = i++, Amount = 270, Date = new DateTime(2014, 04, 19) });
            data.Add(new Data() { Id = i++, Amount = 300, Date = new DateTime(2014, 05, 03) });
            data.Add(new Data() { Id = i++, Amount = 180, Date = new DateTime(2014, 05, 11) });
            data.Add(new Data() { Id = i++, Amount = 240, Date = new DateTime(2014, 08, 17) });
            data.Add(new Data() { Id = i++, Amount = 240, Date = new DateTime(2014, 09, 10) });
            data.Add(new Data() { Id = i++, Amount = 225, Date = new DateTime(2014, 09, 26) });
            data.Add(new Data() { Id = i++, Amount = 135, Date = new DateTime(2014, 10, 01) });
            data.Add(new Data() { Id = i++, Amount = 255, Date = new DateTime(2014, 10, 11) });
            data.Add(new Data() { Id = i++, Amount = 255, Date = new DateTime(2014, 10, 20) });
            data.Add(new Data() { Id = i++, Amount = 255, Date = new DateTime(2014, 10, 28) });
            data.Add(new Data() { Id = i++, Amount = 255, Date = new DateTime(2014, 11, 05) });
            data.Add(new Data() { Id = i++, Amount = 270, Date = new DateTime(2014, 11, 14) });
            data.Add(new Data() { Id = i++, Amount = 240, Date = new DateTime(2014, 11, 18) });
            data.Add(new Data() { Id = i++, Amount = 210, Date = new DateTime(2014, 11, 23) });
            data.Add(new Data() { Id = i++, Amount = 304, Date = new DateTime(2014, 11, 29) });
            data.Add(new Data() { Id = i++, Amount = 272, Date = new DateTime(2014, 12, 04) });
            data.Add(new Data() { Id = i++, Amount = 272, Date = new DateTime(2014, 12, 09) });
            data.Add(new Data() { Id = i++, Amount = 255, Date = new DateTime(2014, 12, 14) });
            data.Add(new Data() { Id = i++, Amount = 300, Date = new DateTime(2014, 12, 18) });
            data.Add(new Data() { Id = i++, Amount = 255, Date = new DateTime(2014, 12, 23) });
            data.Add(new Data() { Id = i++, Amount = 315, Date = new DateTime(2014, 12, 28) });
            data.Add(new Data() { Id = i++, Amount = 240, Date = new DateTime(2015, 01, 01) });
            data.Add(new Data() { Id = i++, Amount = 285, Date = new DateTime(2015, 01, 05) });
            data.Add(new Data() { Id = i++, Amount = 240, Date = new DateTime(2015, 01, 09) });
            data.Add(new Data() { Id = i++, Amount = 240, Date = new DateTime(2015, 01, 13) });
            data.Add(new Data() { Id = i++, Amount = 255, Date = new DateTime(2015, 01, 17) });
            data.Add(new Data() { Id = i++, Amount = 255, Date = new DateTime(2015, 01, 21) });
            data.Add(new Data() { Id = i++, Amount = 255, Date = new DateTime(2015, 01, 25) });
            data.Add(new Data() { Id = i++, Amount = 285, Date = new DateTime(2015, 01, 29) });
            data.Add(new Data() { Id = i++, Amount = 255, Date = new DateTime(2015, 02, 06) });
            data.Add(new Data() { Id = i++, Amount = 270, Date = new DateTime(2015, 02, 10) });
            data.Add(new Data() { Id = i++, Amount = 225, Date = new DateTime(2015, 02, 14) });
            data.Add(new Data() { Id = i++, Amount = 225, Date = new DateTime(2015, 02, 14) });
            data.Add(new Data() { Id = i++, Amount = 240, Date = new DateTime(2015, 02, 21) });
            data.Add(new Data() { Id = i++, Amount = 285, Date = new DateTime(2015, 02, 25) });
            data.Add(new Data() { Id = i++, Amount = 255, Date = new DateTime(2015, 03, 01) });
            data.Add(new Data() { Id = i++, Amount = 255, Date = new DateTime(2015, 03, 06) });
            data.Add(new Data() { Id = i++, Amount = 255, Date = new DateTime(2015, 03, 11) });
            data.Add(new Data() { Id = i++, Amount = 240, Date = new DateTime(2015, 03, 16) });
            data.Add(new Data() { Id = i++, Amount = 210, Date = new DateTime(2015, 03, 21) });
            data.Add(new Data() { Id = i++, Amount = 270, Date = new DateTime(2015, 03, 26) });
            data.Add(new Data() { Id = i++, Amount = 240, Date = new DateTime(2015, 03, 31) });
            data.Add(new Data() { Id = i++, Amount = 270, Date = new DateTime(2015, 04, 05) });
            data.Add(new Data() { Id = i++, Amount = 240, Date = new DateTime(2015, 04, 11) });
            data.Add(new Data() { Id = i++, Amount = 270, Date = new DateTime(2015, 04, 17) });
            data.Add(new Data() { Id = i++, Amount = 240, Date = new DateTime(2015, 04, 24) });
            data.Add(new Data() { Id = i++, Amount = 255, Date = new DateTime(2015, 05, 01) });
            data.Add(new Data() { Id = i++, Amount = 285, Date = new DateTime(2015, 05, 08) });
            data.Add(new Data() { Id = i++, Amount = 240, Date = new DateTime(2015, 05, 18) });
            data.Add(new Data() { Id = i++, Amount = 240, Date = new DateTime(2015, 05, 27) });
            data.Add(new Data() { Id = i++, Amount = 240, Date = new DateTime(2015, 06, 03) });
            data.Add(new Data() { Id = i++, Amount = 255, Date = new DateTime(2015, 06, 27) });


        }

    }
}
