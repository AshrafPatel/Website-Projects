import React from "react"
import "./Form.css"

const form = (props) => {
    let errorMessage
    if (props.message.length > 0) {
        errorMessage = "Error\r " + props.message;
    }


    return (
        <div id="4thSect" className="ContactMe">
            <form action="https://formspree.io/4shr4f@live.co.uk"method="POST">
                <fieldset>
                    <h2 id="getInTouch">Contact Me</h2> 
                    <label for="email">Email</label>
                    <br/>  
                    <input type="email" name="_replyto" onChange={props.changeHandler} value={props.stateProps._replyto}/>
                    <p>Please enter your message</p> 
                    <textarea name="body" onChange={props.changeHandler} value={props.stateProps.body}></textarea>
                    <br/>
                    <p style={{color: "red"}}>{errorMessage}</p>
                    <button type="submit" disabled={props.error}>Send</button>
                </fieldset>
            </form>
        </div>
    )
}

export default form