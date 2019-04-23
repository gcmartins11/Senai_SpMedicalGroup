import React from 'react'
import './Info.css'

export default props => {
    return(
        <div>
            <p className="card-titulo">{props.titulo}</p>
            <p className="card-info">{props.info}</p>
        </div>
    )
}