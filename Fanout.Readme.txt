# Exchange Type ile sadece Publisher ilgilenir. Consumer, Queue ile ilgilenir.
## Publisher kýsýmlarýnda queue declare etmeye gerek yoktur. Publisher sadece exchange ile ilgilenir.
## Publisher, exchange'e mesajý gönderir. Exchange, mesajý alýr ve routing key'e göre ilgili queue'ye gönderir.
## Consumer, queue'yi dinler ve mesajý alýr.


## Fanout Exchange:
	- Fanout exchange, mesajý aldýðýnda, mesajý baðlý olan tüm queue'lere gönderir.
	- Routing key'e bakmaz.
	- Publisher, mesajý fanout exchange'e gönderir.
	- Fanout exchange, mesajý baðlý olan tüm queue'lere gönderir.


	-En sade exchange tipimizdir. 
	Publisher tarafýndan gönderilen mesajlarý alýp route key tanýmlamasý gibi 
	ayrýmlara ihtiyaç duymadan,Fanout Exchange’e bind olan bütün kuyruklara 
	ayný ve eþit bir þekilde iletilmesini saðlayan yapýdýr.

	- Bu yapýyý radyo yayýný yapan bir frekansa ya da Youtube üzerinden 
	yayýn yapan bir Youtuber’a benzetmek mümkün. 
	Tüm dinleyiciler ilgili kanala eriþtiðinde ayný mesajlarý alýr.