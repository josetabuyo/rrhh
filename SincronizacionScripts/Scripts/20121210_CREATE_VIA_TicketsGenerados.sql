--Tabla de tickets generados

create table dbo.VIA_TicketsGenerados(
idTicket int not null identity  primary key,
codigo varchar(8) not null,
fecha  datetime
)