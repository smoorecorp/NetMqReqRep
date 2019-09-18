using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NetMq.ReqRep.PeopleService
{
    /// <summary>
    /// Class repsenting a Person 
    /// </summary>
    public class Person : IPerson
    {

        /// <summary>
        /// Person Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Person First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Person Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Person City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Person State
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Person Country
        /// </summary>
        public string Country { get; set; }

        public override string ToString()
        {
            StringBuilder row = new StringBuilder();

            char quote = '"';

            string quoteAndComma = quote + "," + quote;

            row.Append(quote).Append(Id).Append(quoteAndComma).Append(FirstName).Append(quoteAndComma).Append(LastName).Append(quoteAndComma).Append(City).Append(quoteAndComma).Append(State).Append(quoteAndComma).Append(Country).Append(quote);

            return row.ToString();

        }
    }
}
