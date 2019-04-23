import React from 'react'
import {Switch, Route, Redirect} from 'react-router'

import Login from './Login/Login'
import Consultas from './Consultas/Consultas'

export default props =>
    <Switch>
        <Route exact path="/login" component={Login}/>
        <Route path="/Consultas" component={Consultas}/>
        <Redirect from="*" to="/login"/>
    </Switch>