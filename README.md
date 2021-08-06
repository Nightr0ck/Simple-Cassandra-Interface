# Simple-Cassandra-Interface

Commands:<br>
<br>
Pull latest Cassandra image<br>
```docker pull cassandra:latest```<br>
<br>
Start Cassandra server in Docker<br>
```docker run --rm -d --name cassandra --hostname cassandra --network cassandra -p 9042:9042 cassandra```<br>
<br>
Start CQLSH<br>
```docker run --rm -it --network cassandra nuvo/docker-cqlsh cqlsh cassandra 9042 --cqlversion="3.4.5"```
