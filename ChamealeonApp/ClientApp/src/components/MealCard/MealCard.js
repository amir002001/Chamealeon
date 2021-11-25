import React from 'react'
import './MealCard.css'


export default function MealCard(props) {
    return (
        <div className="meal-card-group">
            {/* <div className="meal-card-thumb" style={{ backgroundImage: "url(" + props.bg + ")" }}>
            </div> */}
            <div className="meal-card-thumb" style={{ backgroundImage: "url(https://www.pexels.com/photo/1640777/download/)" }}></div>
            <div className="meal-card-text">
                <p className="card-title">Carrot & Rice with Bell Pepper</p>
                {/* <a href="#">{props.name}</a> */}
                <div className="macros-container">
                    <div className="macro-group">
                        <p className="macro-title">Calories</p>
                        <p className="macro-value">800</p>
                    </div>
                    <div className="macro-group">
                        <p className="macro-title">Carbs</p>
                        <p className="macro-value">800</p>
                    </div>
                    <div className="macro-group">
                        <p className="macro-title">Protein</p>
                        <p className="macro-value">800</p>
                    </div>
                    <div className="macro-group">
                        <p className="macro-title">Fat</p>
                        <p className="macro-value">800</p>
                    </div>
                    
                </div>
            </div>
        </div>
    )
}
