﻿namespace NetMq.ReqRep.PeopleService
{
    public interface IPerson
    {
        string City { get; set; }
        string Country { get; set; }
        string FirstName { get; set; }
        string Id { get; set; }
        string LastName { get; set; }
        string State { get; set; }
    }
}