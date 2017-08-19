using _00_BA.Entity;
using _01_BA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BA.BLL
{
    public class CustomerBLL
    {
        private CustomerDataMapper customerDAL;
        private TemporaryCustomerDataMapper tempCustomerDAL;
        public void AddCustomer(Customer customer)
        {
            customerDAL = new CustomerDataMapper();
            IsValidCustomer(customer);
            if (customer is VIPCustomer)
                customerDAL.Insert((VIPCustomer)customer);
            if (customer is IndividualCustomer)
                customerDAL.Insert((IndividualCustomer)customer);
            if (customer is TemporaryCustomer)
                customerDAL.Insert((TemporaryCustomer)customer);
            //customerDAL.SaveChanges();
        }

        private static void IsValidCustomer(Customer customer)
        {
            if (customer == null)
                throw new FormatException("Musteri bos olamaz!");
            if (customer.Id != 0)
                throw new FormatException("Musteriye id degeri atanmamali!");
            if (String.IsNullOrWhiteSpace(customer.SSN))
                throw new ArgumentException("Musteri T.C. numarasi bos gecilemez!");
            if (String.IsNullOrWhiteSpace(customer.FirstName))
                throw new ArgumentException("Musteri adi bos gecilemez!");
            if (String.IsNullOrWhiteSpace(customer.LastName))
                throw new ArgumentException("Musteri soyadi bos gecilemez!");
        }

        public Customer GetCustomerBySSN(string SSN)
        {
            customerDAL = new CustomerDataMapper();
            return customerDAL.GetBySSN(SSN);
        }

        // Tum gecici musteriler
        public List<TemporaryCustomer> GetTemporaryCustomers()
        {
            tempCustomerDAL = new TemporaryCustomerDataMapper();
            return tempCustomerDAL.GetAll();
        }

        public List<TemporaryCustomer> GetRemovedTemporaryCustomers()   /// silinen geçici müşteriler
        {
            tempCustomerDAL = new TemporaryCustomerDataMapper();
            var result = tempCustomerDAL.GetByAll(x => x.IsRemoved == true);
            return result.ToList();
        }

        public void RemoveTemporaryCustomer(TemporaryCustomer tempCustomer)  // geçici müşteriyi sil
        {
            tempCustomerDAL = new TemporaryCustomerDataMapper();
            tempCustomerDAL.Delete(tempCustomer);
            //tempCustomerDAL.SaveChanges();
        }
        public Customer GetCustomer(int CustomerId)
        {
            customerDAL = new CustomerDataMapper();
            return customerDAL.GetById(CustomerId);
        }
    }
}
