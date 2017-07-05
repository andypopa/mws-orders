/*******************************************************************************
 * Copyright 2009-2015 Amazon Services. All Rights Reserved.
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 *
 * You may not use this file except in compliance with the License. 
 * You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 * This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 * CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 * specific language governing permissions and limitations under the License.
 *******************************************************************************
 * Marketplace Web Service Orders
 * API Version: 2013-09-01
 * Library Version: 2015-03-05
 * Generated: Tue Mar 03 22:11:26 GMT 2015
 */

using System.Linq;
using System.Xml.Linq;
using MarketplaceWebServiceOrders.Model;
using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace MarketplaceWebServiceOrders {

    /// <summary>
    /// Runnable sample code to demonstrate usage of the C# client.
    ///
    /// To use, import the client source as a console application,
    /// and mark this class as the startup object. Then, replace
    /// parameters below with sensible values and run.
    /// </summary>
    public class MarketplaceWebServiceOrdersSample {

        public static void Main(string[] args)
        {
            // TODO: Set the below configuration variables before attempting to run

            // Developer AWS access key
            var accessKey = "AKIAJLJOWQCL7OIPTRGQ";

            // Developer AWS secret key
            var secretKey = "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";

            // The client application name
            var appName = "CSharpSampleCode";

            // The client application version
            var appVersion = "1.0";

            // The endpoint for region service and version (see developer guide)
            // ex: https://mws.amazonservices.com
            var serviceURL = "https://mws.amazonservices.com";

            // Create a configuration object
            var config = new MarketplaceWebServiceOrdersConfig();
            config.ServiceURL = serviceURL;
            // Set other client connection configurations here if needed
            // Create the client itself
            MarketplaceWebServiceOrders client = new MarketplaceWebServiceOrdersClient(accessKey, secretKey, appName, appVersion, config);

            var sample = new MarketplaceWebServiceOrdersSample(client);
            var orders = new List<Order>();
            var i = 1;

            // Uncomment the operation you'd like to test here
            // TODO: Modify the request created in the Invoke method to be valid
            try 
            {
                ListOrdersResponse response = null;
                
                //response = sample.InvokeGetServiceStatus();
                // response = sample.InvokeListOrderItems();
                // response = sample.InvokeListOrderItemsByNextToken();
                response = sample.InvokeListOrders();
                //var responseXml = XDocument.Load(response.ToXML());
                //var amazonOrderId = new List<string>();
                //amazonOrderId.AddRange(response);
                //response = sample.InvokeGetOrder();
                // response = sample.InvokeListOrdersByNextToken();
                Console.WriteLine("Response:");
                orders.AddRange(response.ListOrdersResult.Orders);

                QueryOrders(response.ListOrdersResult.NextToken, sample, ref orders, ref i);

                var rhmd = response.ResponseHeaderMetadata;
                // We recommend logging the request id and timestamp of every call.
                Console.WriteLine("RequestId: " + rhmd.RequestId);
                Console.WriteLine("Timestamp: " + rhmd.Timestamp);

            }
            catch (MarketplaceWebServiceOrdersException ex)
            {
                // Exception properties are important for diagnostics.
                var rhmd = ex.ResponseHeaderMetadata;
                Console.WriteLine("Service Exception:");
                if(rhmd != null)
                {
                    Console.WriteLine("RequestId: " + rhmd.RequestId);
                    Console.WriteLine("Timestamp: " + rhmd.Timestamp);
                }
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("StatusCode: " + ex.StatusCode);
                Console.WriteLine("ErrorCode: " + ex.ErrorCode);
                Console.WriteLine("ErrorType: " + ex.ErrorType);
                throw ex;
            }
            var json = JsonConvert.SerializeObject(orders);
            Console.WriteLine(json);
            System.IO.File.WriteAllLines(@"orders.json", json.Split('\n'));
            Console.ReadLine();
        }

        private readonly MarketplaceWebServiceOrders client;

        public MarketplaceWebServiceOrdersSample(MarketplaceWebServiceOrders client)
        {
            this.client = client;
        }

        public GetOrderResponse InvokeGetOrder(List<string> amazonOrderId )
        {
            // Create a request.
            var request = new GetOrderRequest();
            var sellerId = "AWZW1NHHAB14U";
            request.SellerId = sellerId;
            //string mwsAuthToken = "AKIAJLJOWQCL7OIPTRGQ";
            //request.MWSAuthToken = mwsAuthToken;
            //var amazonOrderId = new List<string>();
            //amazonOrderId.Add("002-9349621-5019419");
            request.AmazonOrderId = amazonOrderId;
            return this.client.GetOrder(request);
        }

        public GetServiceStatusResponse InvokeGetServiceStatus()
        {
            // Create a request.
            var request = new GetServiceStatusRequest();
            var sellerId = "AWZW1NHHAB14U";
            request.SellerId = sellerId;
            //string mwsAuthToken = "example";
            //request.MWSAuthToken = mwsAuthToken;
            return this.client.GetServiceStatus(request);
        }

        public ListOrderItemsResponse InvokeListOrderItems()
        {
            // Create a request.
            var request = new ListOrderItemsRequest();
            var sellerId = "AWZW1NHHAB14U";
            request.SellerId = sellerId;
            //string mwsAuthToken = "example";
            //request.MWSAuthToken = mwsAuthToken;
            var amazonOrderId = "example";
            request.AmazonOrderId = amazonOrderId;

            //XElement xdoc = XElement.Load("C:\\data.xml");
            //IEnumerable<XElement> childList =
            //    from el in xdoc.Elements().
            //    select el;


            return this.client.ListOrderItems(request);
        }

        public ListOrderItemsByNextTokenResponse InvokeListOrderItemsByNextToken()
        {
            // Create a request.
            var request = new ListOrderItemsByNextTokenRequest();
            var sellerId = "AWZW1NHHAB14U";
            request.SellerId = sellerId;
            //string mwsAuthToken = "example";
            //request.MWSAuthToken = mwsAuthToken;
            var nextToken = "example";
            request.NextToken = nextToken;
            return this.client.ListOrderItemsByNextToken(request);
        }

        public ListOrdersResponse InvokeListOrders()
        {
            // Create a request.
            var request = new ListOrdersRequest();
            var sellerId = "AWZW1NHHAB14U";
            request.SellerId = sellerId;
            //string mwsAuthToken = "example";
            //request.MWSAuthToken = mwsAuthToken;
            DateTime createdAfter = new DateTime(2017,01,01);
            request.CreatedAfter = createdAfter;
            //DateTime createdBefore = new DateTime();
            //request.CreatedBefore = createdBefore;
            //DateTime lastUpdatedAfter = new DateTime();
            //request.LastUpdatedAfter = lastUpdatedAfter;
            //DateTime lastUpdatedBefore = new DateTime();
            //request.LastUpdatedBefore = lastUpdatedBefore;
            //List<string> orderStatus = new List<string>();
            //request.OrderStatus = orderStatus;
            var marketplaceId = new List<string>();
            marketplaceId.Add("ATVPDKIKX0DER");
            request.MarketplaceId = marketplaceId;
            //var fulfillmentChannel = new List<string>();
            //request.FulfillmentChannel = fulfillmentChannel;
            //var paymentMethod = new List<string>();
            //request.PaymentMethod = paymentMethod;
            //var buyerEmail = "example";
            //request.BuyerEmail = buyerEmail;
            //var sellerOrderId = "example";
            //request.SellerOrderId = sellerOrderId;
            //decimal maxResultsPerPage = 1;
            //request.MaxResultsPerPage = maxResultsPerPage;
            //var tfmShipmentStatus = new List<string>();
            //request.TFMShipmentStatus = tfmShipmentStatus;
            return this.client.ListOrders(request);
        }

        public ListOrdersByNextTokenResponse InvokeListOrdersByNextToken(string nextToken)
        {
            // Create a request.
            var request = new ListOrdersByNextTokenRequest();
            var sellerId = "AWZW1NHHAB14U";
            request.SellerId = sellerId;
            //string mwsAuthToken = "example";
            //request.MWSAuthToken = mwsAuthToken;
            request.NextToken = nextToken;
            return this.client.ListOrdersByNextToken(request);
        }

        public static void QueryOrders(string nextToken, MarketplaceWebServiceOrdersSample sample, ref List<Order> orders, ref int i)
        {
            try
            {
                if (nextToken == null) return;
                var nextTokenResponse = sample.InvokeListOrdersByNextToken(nextToken);
                nextToken = nextTokenResponse.ListOrdersByNextTokenResult.NextToken;
                orders.AddRange(nextTokenResponse.ListOrdersByNextTokenResult.Orders);
                Console.WriteLine("Request #{0}", i);
                i++;
                QueryOrders(nextToken, sample, ref orders, ref i);
            }
            catch (MarketplaceWebServiceOrdersException ex)
            {
                if (ex.StatusCode == HttpStatusCode.ServiceUnavailable && ex.Message.Contains("throt"))
                {
                    Console.WriteLine("Pausing for 5 sec");
                    System.Threading.Thread.Sleep(10000);
                    QueryOrders(nextToken, sample, ref orders, ref i);
                }
                else
                {
                    Console.WriteLine("Fatal error");
                    Console.WriteLine(ex);
                }
            }
        } 
    }
}
