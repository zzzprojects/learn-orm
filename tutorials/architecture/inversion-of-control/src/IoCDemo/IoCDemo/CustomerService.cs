using System;
using System.Collections.Generic;
using System.Text;

namespace IoCDemo
{
    public class CustomerService
    {
        private readonly ILogger _logger;
        public CustomerService(ILogger logger)
        {
            _logger = logger;
        }
        public void Log(string message)
        {
            _logger.Log(message);
        }
    }
}
