import {
    createBottomTabNavigator,
    createAppContainer,
    createStackNavigator,
    createSwitchNavigator
} from "react-navigation";

import Login from './Pages/Login'
import Consultas from './Pages/Consultas'

console.disableYellowBox= true

const AuthStack = createStackNavigator({Login})

const MainNavigator = createBottomTabNavigator(
    { "Consultas": Consultas }
)


export default createAppContainer(
    createSwitchNavigator(
        {
            MainNavigator,
            AuthStack
        },
        {
            initialRouteName: "AuthStack",
        }
    )
)
