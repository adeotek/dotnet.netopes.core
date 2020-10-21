// using System.Collections.Generic;
// using System.Linq;
// using System.Web;
// using Microsoft.AspNetCore.Http.Extensions;
// using Microsoft.AspNetCore.WebUtilities;
//
// namespace Netopes.Core.Helpers
// {
//     public static class UrlHelpers
//     {
//         public static (string, QueryBuilder) SplitUrl(string url)
//         {
//             if (string.IsNullOrEmpty(url))
//             {
//                 return (url, new QueryBuilder());
//             }
//             var decodedUrl = HttpUtility.UrlDecode(url);
//             if (!decodedUrl.Contains('?'))
//             {
//                 return (url, new QueryBuilder());
//             }
//             var query = QueryHelpers.ParseQuery(decodedUrl.Substring(decodedUrl.IndexOf('?') + 1));
//             var baseUrl = decodedUrl.Substring(0, decodedUrl.IndexOf('?'));
//             var queryItems = query.SelectMany(x => x.Value, (col, value) => new KeyValuePair<string, string>(col.Key, value)).ToList();
//
//             return (baseUrl, new QueryBuilder(queryItems));
//         }
//
//         public static string AddOrReplaceQueryStringElement(string url, string qsKey, string qsValue)
//         {
//             var redirectUrl = HttpUtility.UrlDecode(url);
//             QueryBuilder qb;
//             if (redirectUrl.Contains('?'))
//             {
//                 var query = QueryHelpers.ParseQuery(redirectUrl.Substring(redirectUrl.IndexOf('?') + 1));
//                 redirectUrl = redirectUrl.Substring(0, redirectUrl.IndexOf('?'));
//                 var queryItems = query.SelectMany(x => x.Value, (col, value) => new KeyValuePair<string, string>(col.Key, value)).ToList();
//                 queryItems.RemoveAll(i => i.Key == qsKey);
//                 qb = new QueryBuilder(queryItems) { { qsKey, qsValue } };
//             }
//             else
//             {
//                 qb = new QueryBuilder { { qsKey, qsValue } };
//             }
//
//             return $"{redirectUrl}{qb.ToQueryString()}";
//         }
//     }
// }