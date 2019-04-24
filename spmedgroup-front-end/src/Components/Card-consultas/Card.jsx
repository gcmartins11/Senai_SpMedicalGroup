import React from 'react'
import './Card.css'

import Info from './Info'

export default props => {
    return (
        <div className="card">
            <Info titulo="Especialidade" info={props.especialidade}/>
            <Info titulo="Doutor(a)" info={props.medico}/>
            <div className="data-hora">
                <Info titulo="Data" info={props.data}/>
                <Info titulo="Hora" info={props.hora}/>
            </div>
            <Info titulo="Status" info={props.status}/>
        </div>
    )
}