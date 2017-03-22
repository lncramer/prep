using System.Collections.Generic;
using code.prep.people;
using code.web.features.list_people;
using code.web.stubs;

namespace code.web
{
    public class ResponseHandler : ISendResponsesToTheClient
    {
        private readonly IFormatDataForResponse formatter;
        private readonly ISendResponses response_sender;

        public ResponseHandler() : this(Stubs.data_formatter, Stubs.response_sender)
        {
        }

        public ResponseHandler(IFormatDataForResponse formatter,
                               ISendResponses response_sender)
        {
            this.formatter = formatter;
            this.response_sender = response_sender;
        }

        public void send(IEnumerable<Person> data)
        {
            var formattedData = formatter(data);

            response_sender(formattedData);
        }
    }
}