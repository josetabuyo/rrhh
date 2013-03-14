var areaDeCastagneto = { id: 1,
    descripcion: "Area de Castagneto"
}

var areaDeFabi = { id: 2,
    descripcion: "Area de Fabi"
}

var areaDeMarta = { id: 3,
    descripcion: "Area de Marta"
}

var areaDeViaticos = { id: 5,
        descripcion: "Viaticos"
}

var documentoEnAreaDeCastagneto = {
    id: 1,
    tipo: { id: 2,
        descripcion: "tipo1"
    },
    categoria: { id: 1,
        descripcion: "categoria1"
    },
    numero: 111,
    ticket: "AAA111",
    extracto: "blabla",
    fechaDeAlta: "10/10/10",
    areaCreadora: areaDeViaticos,
    areaActual: areaDeCastagneto,
    areaDestino: areaDeFabi,
    comentarios: "blablablabla",
    enAreaActualHace: { dias:1,
                        horas:1,
                        minutos:1 
    }
}

var documentoEnAreaDeMarta = {
    id: 2,
    tipo: { id: 1,
        descripcion: "tipo1"
    },
    categoria: { id: 1,
        descripcion: "categoria1"
    },
    numero: 12,
    ticket: "AAA112",
    extracto: "blabla",
    fechaDeAlta: "10/10/10",
    areaCreadora: areaDeViaticos,
    areaActual: areaDeMarta,
    areaDestino: areaDeFabi,
    comentarios: "blablablabla",
    enAreaActualHace: { dias: 1,
        horas: 1,
        minutos: 1
    }
}

var InasistenciasDeBelen = { fecha: "1224043200000",
    descripcion: "Inasistencia Bel"
}

