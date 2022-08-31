using AFI.Core.DomainModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using TinyCsvParser;

namespace AFI.Core.Services
{
    public class CustomerRepositoryFlatFile : ICustomerRepository
    {
        private readonly string _csvFilePath;
        private IList<Customer> _registeredCustomer;

        public CustomerRepositoryFlatFile()
        {
            _csvFilePath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\CSVStore\\CustomerDataStore.csv";
            ParseCSV();
        }

        public Customer GetRegisteredCustomerById(int id)
        {
            return _registeredCustomer.FirstOrDefault(x => x.CustomerID == id);
        }

        public IEnumerable<Customer> GetRegisteredCustomers()
        {
            return _registeredCustomer;
        }

        public int RegisterCustomer(Customer customerToRegister)
        {
            customerToRegister.CustomerID = GetNextUniqueCustomrId();
            try
            {
                WriteToCSV(customerToRegister);
            }
            catch (Exception ex)
            {
                //log exception
                return 0;
            }

            RefreshCustomers();

            return customerToRegister.CustomerID;
        }

        private void RefreshCustomers()
        {
            ParseCSV();
        }

        private void WriteToCSV(Customer customerToRegister)
        {
            using (var w = new StreamWriter(_csvFilePath, true))
            {
                var line = $"{w.NewLine}{customerToRegister.CustomerID},{customerToRegister.FirstName},{customerToRegister.LastName},{customerToRegister.PolicyReferenceNumber},{customerToRegister.DOB},{customerToRegister.Email}";
                w.WriteLine(line);

                w.Flush();
            }
        }

        private int GetNextUniqueCustomrId()
        {
            var c = GetRegisteredCustomers().ToList().OrderByDescending(x => x.CustomerID).FirstOrDefault();
            if (c != null)
                return c.CustomerID + 1;
            return 1;
        }

        private void ParseCSV()
        {
            CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');
            var csvParser = new CsvParser<Customer>(csvParserOptions, new CsvCustomerInputMapping());

            var records = csvParser.ReadFromFile(_csvFilePath, Encoding.UTF8);

            _registeredCustomer = records.Select(x => x.Result).ToList();
        }
    }
}