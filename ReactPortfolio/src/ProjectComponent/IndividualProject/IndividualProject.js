import React from "react"
import "./IndividualProject.css"



const individualProject = (props) => {
    function importAll(r) {
        let images = {};
        // eslint-disable-next-line
        r.keys().map((item) => { images[item.replace('./', '')] = r(item); });
        return images;
    }

    const images = importAll(require.context('./images', false, /\.(png|jpe?g|svg)$/));

    return (
        <div className="project">
                <h2>{props.title}</h2>
                <a href={props.url}><img src={images[props.imageURL]} className="portfolioPics" alt={props.alt} /></a>
                <p>{props.data}</p>
        </div>
    )
}

export default individualProject