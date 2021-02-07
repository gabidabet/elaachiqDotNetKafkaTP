using System;
using System.Collections.Generic;
using System.Linq;
using Confluent.Kafka;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MyWebApplications.Model;
using Newtonsoft.Json;

namespace MyWebApplications.Services{
    [Route("/api/clients")]
    public class ClientRestServices:Controller{

        KafkaPreducer preducer=new KafkaPreducer();

        private MyDbContext dbService{get;set;}

        public ClientRestServices(MyDbContext myDbContext){
            dbService=myDbContext;
        }


        [HttpGet]
        public IEnumerable<Client> clientList(){
            return dbService.Clients;
        }
        
        [HttpPost]
        public Client Save([FromBody]Client client){
            dbService.Clients.Add(client);
            dbService.SaveChanges();
            preducer.preduceMessage(1,new Data{operationType="post",data=client});
            return client;
        }

        [HttpGet("{id}")]
        public Client GetOne(long id){
            return dbService.Clients.FirstOrDefault(cl=>cl.Id==id);
        }

        [HttpDelete("{id}")]
        public Client DeleteClient(long id){
            Console.WriteLine(id);
            Client c = dbService.Clients.FirstOrDefault(cl=>cl.Id==id);
            dbService.Clients.Remove(c);
            dbService.SaveChanges();
            preducer.preduceMessage(1,new Data{operationType="delete",data=c});
            return c;
        }
        [HttpPut("{id}")]
        public Client ModifClient(long id,[FromBody] Client client){
            Console.WriteLine("test de test");
            client.Id=id;
            dbService.Clients.Update(client);
            preducer.preduceMessage(1,new Data{operationType="Put",data=client});
            return client;
        }

        [HttpGet("paginate")]
        public IEnumerable<Client> getClientByPage(int page=0,int size=3){
            int skip=(page-1)*size;
            return dbService.Clients.Skip(skip).Take(size);
        }
        [HttpGet("pagenubmer")]
        public int[] getPageNumber(){
            int[] counts=new int[dbService.Clients.Count()/3];
            for(int i=0;i<counts.Length;++i){
                counts[i]=i+1;
            }
            return counts;
        }

    }
}