using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;


public class CustomerCollection : IEnumerable<Customer>, IEnumerator<Customer>
{

    int position = -1;


    Customer[] customers = new Customer[] {
            new Customer(){ Name = "fred", Address = "sydney", PostCode = "2000" },
            new Customer(){ Name = "jane", Address = "Melbourne", PostCode = "3000" },
            new Customer(){ Name = "joe", Address = "sydney", PostCode = "2000" },
            new Customer(){ Name = "zoe", Address = "Melbourne", PostCode = "3000" },
            new Customer(){ Name = "dave", Address = "sydney", PostCode = "2000" },
            new Customer(){ Name = "jill", Address = "Melbourne", PostCode = "3000" },
            new Customer(){ Name = "frank", Address = "sydney", PostCode = "2000" },
            new Customer(){ Name = "lyn", Address = "Melbourne", PostCode = "3000" },
            new Customer(){ Name = "kev", Address = "Melbourne", PostCode = "3000" }

        };

    public Customer[] AllCustomers
    {
        get
        {
            return customers;
        }
    }

    #region "IEnumerable Implementation"

    public IEnumerator<Customer> GetEnumerator()
    {
        return (IEnumerator<Customer>)this;

    }



    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return (IEnumerator<Customer>)this;
    }


    #endregion

    #region "Extra enumerators"
    public IEnumerable<Customer> Evens
    {
        get
        {
            for (int i = 0; i <= customers.Length; i+=2)
            {
                yield return customers[i];  //A yield statement cuases a temporary halt to the 
                //method and returns a value to the caller.
            }
        }

    }

    public IEnumerable<Customer> Backwards
    {
        get
        {
            for (int i = customers.Count() - 1 ; i >= 0; i--)
            {
                yield return customers[i];  //A yield statement cuases a temporary halt to the 
                                            //method and returns a value to the caller.
            }
        }

    }
    #endregion


    #region "IEnumerator Implementation"
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
        bool more = position < customers.Length;

        if (position >= customers.Length)
            Reset();
        return (more);

    }

    public void Reset()
    {
        position = -1;
    }

    #endregion


}


