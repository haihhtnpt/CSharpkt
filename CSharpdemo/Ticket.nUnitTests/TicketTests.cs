using NUnit.Framework;
using System.ComponentModel.DataAnnotations;
using  CSprj;
using CSprj.Service;
using CSprj.Service.Validation;
using System;

namespace CSharpdemo.nUnitTests
{
    public class TicketTests
    {
     
       [Test]
        public void Payment_Test_1()
        {
            
            Ticket a = new Ticket(new DateTime(2010,11,6),TicketType.Normal);
            if (a.Age < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(a.Age), $"Tuổi phải lớn hơn hoặc bằng 0");
            }
            
            int value = 3000000;
            
            Assert.AreEqual(value, a.Payment);

        }
        [Test]
        public void Payment_Test_2()
        {
            Ticket a = new Ticket(new DateTime(2023, 11, 6), TicketType.Normal);
            if (a.Age < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(a.Age),$"Tuổi phải lớn hơn hoặc bằng 0");
            }
            
            int value = 3000000;
            
            Assert.AreEqual(value, a.Payment);
        }
        [Test]
        public void Payment_Test_3()
        {

            Ticket a = new Ticket(new DateTime(2010, 11, 6), TicketType.Normal);
            if (a.Age < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(a.Age), $"Tuổi phải lớn hơn hoặc bằng 0");
            }

            int value = 1000000;

            Assert.AreEqual(value, a.Payment);

        }
        [Test]
        public void Payment_Test_4()
        {
            Ticket a = new Ticket(new DateTime(2001, 11, 6), TicketType.Vip);
            if (a.Age < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(a.Age), $"Tuổi phải lớn hơn hoặc bằng 0");
            }

            int value = 4000000;

            Assert.AreEqual(value, a.Payment);
        }


    }
}