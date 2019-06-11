import React, { Component } from 'react'
import './ElementoLista.css'

export default class ElementoLista extends Component {

    render() {
        return (
            <div id="ElementoLista">
                    <h3>{this.props.nome}</h3>
                    <h3>|</h3>
                    <h3>{this.props.endereco} - {this.props.numero}</h3>
            </div>

        )
    }
}
