using System;
using DemoLibrary.Models;
using MediatR;

namespace DemoLibrary.Commands
{
    //public class InsertPersonCommand : IRequest<PersonModel>
    //{
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }

    //    public InsertPersonCommand(string firstName, string lastName)
    //    {
    //        FirstName = firstName;
    //        LastName = lastName;
    //    }
    //}

    public record InsertPersonCommand(string FirstName, string LastName) : IRequest<PersonModel>;
}
