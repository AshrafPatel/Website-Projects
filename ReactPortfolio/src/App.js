import React from 'react';
import './App.css';
import Header from './HeaderComponent/Header'
import Intro from "./IntroComponent/Intro"
import Project from "./ProjectComponent/Project"
import projectData from "./ProjectComponent/DetailsProjects"
import About from "./AboutComponent/About"
import Form from "./FormComponent/Form"

class App extends React.Component {
  constructor() {
    super();
    this.state = {
        projects:projectData,
        _replyto: "",
        body: ""
    }
    this.formChangeHandler = this.formChangeHandler.bind(this)
  }

  formChangeHandler(event) {
    const {name, value} = event.target
    this.setState({
      [name]: value
    })
  } 
  
  
  render() {
    // eslint-disable-next-line
    const regexEmail = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    let message = ""
    if (!regexEmail.test(String(this.state._replyto).toLowerCase())) {
      message = "(Please enter a valid email)"
    } else if (this.state.body.length < 25) {
      message = "(Please enter a valid message)"
    }
    let error = message.length > 0 ? true : false

    return (
      <div>
        <Header/>
        <Intro/>
        <Project dataArr={this.state.projects}/>
        <About/>
        <Form changeHandler={this.formChangeHandler} error={error} message={message} stateProps={this.state}/>
      </div>
    )
  }
}

export default App;
