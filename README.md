# Async-Inn

## Hanan Nathem Jalal Saadeh

## 14/4/2022

***Hotel Asset Management system***

![](./img/Async-Inn-Hottel.drawio.png)


Hotel Table :
 Fields: ID, Name, city, state, address, and finally the phone number.
Relation: One to many relation with Rooms Table.

Rooms Table :
Fields: ID, price, room number, pet friendly.
Relation : two forign key,one from room table, and the other from hotel table.

Room table:
Field: ID, nickname, layout.
Relation: one to many with rooms table, and with amenities table.

layout table :
Field: id, one bedroom, two bedrooms, studio.
Relation: one to many with room table.

amintity table :
Field : id,name.
Relation : one to many with amintities table.

AmantityRoomTable :
field : amantity id,roomid.compossite id 