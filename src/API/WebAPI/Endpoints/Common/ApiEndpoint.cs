

using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Endpoints.Common;

public static class ApiEndpoint
{
    /// <summary>
    /// This class is used for endpoints that require a request.
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    public static class WithRequest<TRequest>
    {
        /// <summary>
        /// This marks the endpoint as one that requires a request and returns a response.
        /// </summary>
        /// <typeparam name="TResponse">The type of response that is sent to the user.</typeparam>
        public abstract class WithResponse<TResponse> : EndpointBase
        {
            public abstract Task<ActionResult<TResponse>> HandleAsync(TRequest request);
        }

        /// <summary>
        /// This marks the endpoint as one that requires a request and does not return a response.
        /// </summary>
        public abstract class WithoutResponse : EndpointBase
        {
            public abstract Task<ActionResult> HandleAsync(TRequest request);
        }
    }

    /// <summary>
    /// This class is used for endpoints that are route-specific.
    /// </summary>
    public static class WithRoute
    {
        /// <summary>
        /// This marks the endpoint as one that requires route parameters and returns a response.
        /// </summary>
        /// <typeparam name="TResponse">The type of response that is sent to the user.</typeparam>
        public abstract class WithResponse<TResponse> : EndpointBase
        {
            public abstract Task<ActionResult<TResponse>> HandleAsync([FromRoute] string uid);
        }

        /// <summary>
        /// This marks the endpoint as one that requires route parameters and does not return a response.
        /// </summary>
        public abstract class WithoutResponse : EndpointBase
        {
            public abstract Task<ActionResult> HandleAsync([FromRoute] string uid);
        }
    }

    /// <summary>
    /// This class is used for endpoints that require both route and request parameters.
    /// </summary>
    public static class WithRouteAndRequest<TRequest>
    {
        /// <summary>
        /// This marks the endpoint as one that requires both a route parameter and a request, returning a response.
        /// </summary>
        /// <typeparam name="TResponse">The type of response that is sent to the user.</typeparam>
        public abstract class WithResponse<TResponse> : EndpointBase
        {
            public abstract Task<ActionResult<TResponse>> HandleAsync(TRequest request, [FromRoute] string id);
        }

        /// <summary>
        /// This marks the endpoint as one that requires both a route parameter and a request, and does not return a response.
        /// </summary>
        public abstract class WithoutResponse : EndpointBase
        {
            public abstract Task<ActionResult> HandleAsync(TRequest request, [FromRoute] string id);
        }
    }


    /// <summary>
    /// This class is used for endpoints that do not require a request.
    /// </summary>
    public static class WithoutRequest
    {
        /// <summary>
        /// This marks the endpoint as one that does not require a request and returns a response.
        /// </summary>
        /// <typeparam name="TResponse">The type of response that is sent to the user.</typeparam>
        public abstract class WithResponse<TResponse> : EndpointBase
        {
            public abstract Task<ActionResult<TResponse>> HandleAsync();
        }

        /// <summary>
        /// This marks the endpoint as one that does not require a request and does not return a response.
        /// </summary>
        public abstract class WithoutResponse : EndpointBase
        {
            public abstract Task<ActionResult> HandleAsync();
        }
    }
}

[ApiController, Route("api")]
public abstract class EndpointBase : ControllerBase;