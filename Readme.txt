# Exchange Type ile sadece Publisher ilgilenir. Consumer, Queue ile ilgilenir.
## Publisher k�s�mlar�nda queue declare etmeye gerek yoktur. Publisher sadece exchange ile ilgilenir.
## Publisher, exchange'e mesaj� g�nderir. Exchange, mesaj� al�r ve routing key'e g�re ilgili queue'ye g�nderir.
## Consumer, queue'yi dinler ve mesaj� al�r.


## Fanout Exchange:
	- Fanout exchange, mesaj� ald���nda, mesaj� ba�l� olan t�m queue'lere g�nderir.
	- Routing key'e bakmaz.
	- Publisher, mesaj� fanout exchange'e g�nderir.
	- Fanout exchange, mesaj� ba�l� olan t�m queue'lere g�nderir.


	-En sade exchange tipimizdir. 
	Publisher taraf�ndan g�nderilen mesajlar� al�p route key tan�mlamas� gibi 
	ayr�mlara ihtiya� duymadan,Fanout Exchange�e bind olan b�t�n kuyruklara 
	ayn� ve e�it bir �ekilde iletilmesini sa�layan yap�d�r.

	- Bu yap�y� radyo yay�n� yapan bir frekansa ya da Youtube �zerinden 
	yay�n yapan bir Youtuber�a benzetmek m�mk�n. 
	T�m dinleyiciler ilgili kanala eri�ti�inde ayn� mesajlar� al�r.