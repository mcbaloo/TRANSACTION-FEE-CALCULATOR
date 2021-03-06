﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRANSACTION_FEE_CALCULATOR
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal amount;
            Console.WriteLine("Kindly Enter Amount to be transferred");
            //get the amount to be transferred;
            try
            {
                amount = Convert.ToDecimal(Console.ReadLine());
                //compute service charge
                var charge = FeeHelper.computeServiceCharge(amount);
                
                if (charge != null)
                {
                    var transferAmount = amount - Convert.ToDecimal(charge);
                    Console.WriteLine($"Amount : {amount}");
                    Console.WriteLine($"Transfer Amount: {transferAmount}");
                    Console.WriteLine($"Bank Charge:  {charge}");

                    Console.WriteLine($"Debit Amount: {transferAmount + FeeHelper.computeServiceCharge(transferAmount)}");
                    //proceed with other actions
                }
                else
                {
                    Console.WriteLine("Sorry we cannot process your transaction. Try to process another amount");
                    //proceed with any other information
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Enter a Valid Number");
            }
            Console.ReadKey();
        }
    }
}
