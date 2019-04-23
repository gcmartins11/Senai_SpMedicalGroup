import React from 'react'
import './Card.css'

import Info from './Info'

function Card() {
    return (
        <div className="card">
            <Info titulo="Especialidade" info="Neurologia"/>
            <Info titulo="Medico" info="Neurologia"/>
            <div className="data-hora">
                <Info titulo="Data" info="01/01/2000"/>
                <Info titulo="Hora" info="12:00"/>
            </div>
            <Info titulo="Status" info="Realizada"/>
        </div>
    )
}

export default Card