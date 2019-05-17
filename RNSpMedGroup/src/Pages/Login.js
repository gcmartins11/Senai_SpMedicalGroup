import React, { Component } from 'react'
import { StyleSheet, View, TextInput, Button, Image } from 'react-native'
import AsyncStorage from '@react-native-community/async-storage'
import jwt from 'jwt-decode'
import api from '../Services/Api'
import logo from '../Img/logo.png'

export default class Login extends Component {
    static navigationOptions = {
        header: null
    };
    
    constructor(props) {
        super(props)
        this.state = {
            email: 'gabriel.cmartins11@gmail.com',
            senha: 'admin'
        }
    }

    _RealizarLogin = async () => {
        const resposta = await api.post('/login', {
            email: this.state.email,
            senha: this.state.senha
        })
        
        await AsyncStorage.setItem('userToken', resposta.data.token)
        await AsyncStorage.setItem('userCredential', jwt(resposta.data.token).role)
        
        if (resposta.data.token !== null) {
            this.props.navigation.navigate("Consultas")
        }
    }

    render() {
        return (
            <View style={styles.container}>
                <Image
                    style={styles.image}
                    source={logo}
                />
                <TextInput
                    style={styles.input}
                    placeholderTextColor={'#fff'}
                    placeholder="Email"
                    onChangeText={email => this.setState({ email })}
                />
                <TextInput
                    style={styles.input}
                    placeholderTextColor={'#fff'}
                    placeholder="Senha"
                    secureTextEntry={true}
                    onChangeText={senha => this.setState({ senha })}
                />
                <Button
                    style={styles.button}
                    title="Login"
                    onPress={this._RealizarLogin.bind(this)}
                    color="#008080"
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
        backgroundColor: '#13C9AA',
    },
    image: {
        width: 159,
        height: 170,
        margin: 20,
        padding: 20,
    },
    input: {
        width: '80%',
        color: '#fff',
        borderBottomColor: '#fff',
        borderBottomWidth: 2,
        marginBottom: 30,
    },
    button: {
        color: '#000'
    }
})