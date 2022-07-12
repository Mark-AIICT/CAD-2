using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;




//This is the tradational way to create a collection of customers to 
//bind to. An Observable collection is probably more simple.
public class CustomerCollection :  IEnumerable<Customer>, IEnumerator<Customer>
{

    int position = -1;


    Customer[] customers = new Customer[] {
            new Customer(){ CustomerName = "fred", Address = "sydney", PostCode = "2000" },
            new Customer(){ CustomerName = "jane", Address = "Melbourne", PostCode = "3000" },
            new Customer(){ CustomerName = "joe", Address = "sydney", PostCode = "2000" },
            new Customer(){ CustomerName = "zoe", Address = "Melbourne", PostCode = "3000" },
            new Customer(){ CustomerName = "dave", Address = "sydney", PostCode = "2000" },
            new Customer(){ CustomerName = "jill", Address = "Melbourne", PostCode = "3000" },
            new Customer(){ CustomerName = "frank", Address = "sydney", PostCode = "2000" },
            new Customer(){ CustomerName = "lyn", Address = "Melbourne", PostCode = "3000" },
            new Customer(){ CustomerName = "kev", Address = "Melbourne", PostCode = "3000" }

        };

    public Customer[] AllCustomers
    {
        get
        {
            return customers;
        }
    }





    public IEnumerator<Customer> GetEnumerator()
    {
        return (IEnumerator<Customer>)this;

    }



    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return (IEnumerator<Customer>)this;
    }




    public Customer Current
    {
        get { return customers[position]; }
    }


    public void Dispose()
    {

    }


    object System.Collections.IEnumerator.Current
    {
        get { return customers[position]; }
    }

    public bool MoveNext()
    {
        position++;
        return (position < customers.Length);

    }

    public void Reset()
    {
        position = 0;
    }


}


