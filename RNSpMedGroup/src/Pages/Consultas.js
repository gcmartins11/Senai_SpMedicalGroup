import React, {Component} from 'react'
import { StyleSheet, View, TextInput, Button, Text } from 'react-native'
import AsyncStorage from '@react-native-community/async-storage';
import api from '../Services/Api'

export default class Consultas extends Component {
    constructor(props) {
        super(props)
        this.state = {
            token: '',
            role: '',
            listaConsultas: []
        }
    }

    _BuscarToken = async() => {
        const token = await AsyncStorage.getItem('userToken')
        this.setState({token})
        // console.warn(this.state.token)
        this._FazerRequest()
    }

    _FazerRequest = async () => {
        const resposta = await api.get('/consultas', {
            headers: {
                'Authorization' : 'Bearer ' + (this.state.token)
            }
        })

        const listaConsultas = resposta.data
        console.warn(listaConsultas)
    }

    componentDidMount() {
        this._BuscarToken()
    }

    render() {
        return (
            <Button
                    title="Request"
                    onPress={this._FazerRequest.bind(this)}
                    color="#000"
                />
        )
    }
}