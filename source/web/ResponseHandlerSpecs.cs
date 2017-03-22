using System.Collections.Generic;
using code.prep.people;
using code.web.features.list_people;
using developwithpassion.specifications.assertions.core;
using developwithpassion.specifications.assertions.interactions;
using Machine.Specifications;
using spec = developwithpassion.specifications.use_engine<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code.web
{
    [Subject(typeof(ResponseHandler))]
    public class ResponseHandlerSpecs
    {

        public abstract class concern : spec.observe<ISendResponsesToTheClient, ResponseHandler>
        {
        }


        public class when_sending_a_response_to_the_client : concern
        {
            private Establish c = () =>
            {
                formatter = depends.on<IFormatDataForResponse>();
                list = new List<Person>();
                formattedData = "cool";
                depends.on<IFormatDataForResponse>(x =>
                {
                    x.ShouldEqual(list);
                    return formattedData;
                });
//                depends.on<ISendResponses>(x =>
//                {
//                    x.ShouldEqual(formattedData);
//                });
                //                formatter.setup(x => x.format(list)).Return(formattedData);
            };

            Because b = () =>
                sut.send(list);

            It gives_the_formatted_data_to_a_dispatcher = () =>
            {
                response_sender.should().received(x => x(formattedData));
            };

            static IFormatDataForResponse formatter;
            static ISendResponses response_sender; 
            static IEnumerable<Person> list;
            static string formattedData;
        }
    }
}