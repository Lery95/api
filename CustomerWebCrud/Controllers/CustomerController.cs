using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CustomerWebCrud.Models;

namespace CustomerWebCrud.Controllers
{
    public class CustomerController : ApiController
    {
        CustomerDBEntities objEntity = new CustomerDBEntities();

        // GET: all Customer 
        public IQueryable<Customer> Get()
        {
            try
            {
                return objEntity.Customers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: Customer by id
        public IHttpActionResult Get(int custId)
        {
            Customer objCust = new Customer();
            try
            {
                objCust = objEntity.Customers.Find(custId);
                if (objCust == null)
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {
                throw;
            }
            return Ok(objCust);
        }

        //POST: insert
        public IHttpActionResult Post(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                objEntity.Customers.Add(customer);
                objEntity.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(customer);
        }

        //PUT: update
        public IHttpActionResult Put(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Customer objCust = new Customer();
                objCust = objEntity.Customers.Find(customer.CustId);

                if (objCust != null)
                {
                    objCust.CustName = customer.CustName;
                    objCust.PhoneNumber = customer.PhoneNumber;
                    objCust.CustEmail = customer.CustEmail;
                    objCust.Address = customer.Address;
                    objCust.PostCode = customer.PostCode;
                }
                objEntity.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(customer);
        }

        //DELETE: delete
        public IHttpActionResult Delete(int id)
        {
            Customer customer = objEntity.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            objEntity.Customers.Remove(customer);
            objEntity.SaveChanges();

            return Ok(customer);
        }
    }
}