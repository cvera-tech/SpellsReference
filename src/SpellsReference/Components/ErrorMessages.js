import React from 'react';

export default function ErrorMessages({ messages }) {
    if (messages && messages.length > 0) {
        return (
            <div>
                <p>The following errors were found:</p>
                <ul>
                    {
                        messages.map((message, index) => (
                            <li key={index}>{message}</li>
                        ))
                    }
                </ul>
            </div>
        )
    }
    return null;
}