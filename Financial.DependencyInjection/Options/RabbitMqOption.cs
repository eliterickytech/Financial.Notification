using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.DependencyInjection.Options
{
    public class RabbitMqOption
    {
        public string Url { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RetryIntervals { get; set; }
    }

}
