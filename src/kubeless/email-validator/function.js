const re = /^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;

module.exports = {
    validate: function(event, context) {
       if (!event.data.email) {
          const { response } = event.extensions;
          response.writeHead(400);
          return;
       }
       return {
           validation: re.test(event.data.email)
       };
    }
};
