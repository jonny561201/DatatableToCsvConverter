using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DatatableToCsv
{
    [TestFixture]
    public class DataTableToCsvTest
    {
        private DataTableToCsv _dataToCsv;
        private DataTable _dataTable;

        [SetUp]
        public void Setup()
        {
            _dataToCsv = new DataTableToCsv();
            _dataTable = new DataTable();
            _dataTable.Columns.Add("Column1", typeof(String));
            _dataTable.Columns.Add("Column2", typeof(String));
        }

        [Test]
        public void ConvertSingleRowOfDataTableToCsv()
        {
            var actual = _dataToCsv.ToCsv(_dataTable);

            Assert.AreEqual("Column1,Column2,", actual);
        }

        [Test]
        public void DoesNotCreateCsvForEmptyTable()
        {
            DataTable dataTable = new DataTable();

            var actual = _dataToCsv.ToCsv(dataTable);

            Assert.AreEqual("", actual);
        }

        [Test]
        public void AddsReturnCarrageAtEndOfColumn()
        {
            _dataTable.Rows.Add("testRow1", "testRow2");

            var actual = _dataToCsv.ToCsv(_dataTable);

            Assert.AreEqual("Column1,Column2,\ntestRow1,testRow2,", actual);
        }

        [Test]
        public void AddMutipleRowsToCsv()
        {
            _dataTable.Rows.Add("testRow1", "testRow2");
            _dataTable.Rows.Add("testRow3", "testRow4");

            var actual = _dataToCsv.ToCsv(_dataTable);

            Assert.AreEqual("Column1,Column2,\ntestRow1,testRow2,\ntestRow3,testRow4,", actual);
        }

        [Test]
        public void AddMultipleValueTyoes()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("DateTime", typeof (DateTime));
            dataTable.Columns.Add("Int", typeof (int));
            dataTable.Columns.Add("Bool", typeof (bool));

            dataTable.Rows.Add(DateTime.Parse("02/15/2016"), 123, true);

            var actual = _dataToCsv.ToCsv(dataTable);

            Assert.AreEqual("DateTime,Int,Bool,\n2/15/2016 12:00:00 AM,123,True,", actual);
        }
    }
}
