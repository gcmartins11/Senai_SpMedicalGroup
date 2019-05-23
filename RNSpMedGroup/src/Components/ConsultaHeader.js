import React, {Component} from 'react'
import { View, Text, StyleSheet, TouchableOpacity } from 'react-native'

class ConsultaHeader extends Component {
    constructor(props) {
        super(props)
        this.state = {

        }
    }

    _Sair() {
        console.warn("Sair")
        this.props.navigation.push("Login")
    }

    render() {
        return (
            <View style={styles.header}>
                <Text>Opa</Text>
                <TouchableOpacity
                onPress={this._Sair}
                >
                    <Text>Opa</Text>
                </TouchableOpacity>
            </View>
        )
    }      
}

const styles = StyleSheet.create({
    header: {
        width: '100%',
        height: 56,
        alignItems: 'center',
        justifyContent: 'space-between',
        flexDirection: 'row',
        backgroundColor: '#13C9AA',
        paddingLeft: 16,
        paddingRight: 16
    }
})

export default ConsultaHeader