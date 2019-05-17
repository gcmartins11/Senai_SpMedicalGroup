import React, { Component } from 'react'
import { StyleSheet, View, TextInput, Button, Text } from 'react-native'
import AsyncStorage from '@react-native-community/async-storage';
import api from '../Services/Api'
import { FlatList } from 'react-native-gesture-handler';
import { isIfStatement } from '@babel/types';

export default class Consultas extends Component {
    constructor(props) {
        super(props)
        this.state = {
            token: '',
            role: '',
            listaConsultas: []
        }
    }

    componentDidMount() {
        this._BuscarDados()
    }

    _BuscarDados = async () => {
        const token = await AsyncStorage.getItem('userToken')
        const role = await AsyncStorage.getItem('userCredential')
        this.setState({ token })
        this.setState({ role })
        // console.warn(token)
        // console.warn(role)

        this._FazerRequest()
    }

    _FazerRequest = async () => {
        const resposta = await api.get('/consultas', {
            headers: {
                'Authorization': 'Bearer ' + (this.state.token)
            }
        })

        this.setState({listaConsultas: resposta.data})
        console.warn(this.state.listaConsultas)
    } 

    render() {
        return (
            <View style={styles.container}>
                <FlatList
                    data= {this.state.listaConsultas}
                    renderItem= {({ item }) => 
                        <Text>
                            {item.id}, 
                            {item.dataConsulta}, 
                            {item.horaConsulta}, 
                            {item.nomePaciente}, 
                            {isIfStatement.nomeMedico}, 
                            {item.especialidade}, 
                            {item.status}, 
                            {item.descricao}
                        </Text>
                    }
                />

            </View>
        )
    }
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        flexDirection: 'column',
        justifyContent: 'center',
        alignItems: 'center',
    },
})