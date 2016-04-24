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

    }
}
