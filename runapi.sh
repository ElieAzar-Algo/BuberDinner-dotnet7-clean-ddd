#!/bin/bash

# Run the dotnet command and capture the output
# output=$(dotnet run --project ./BuberDinner.Api)
dotnet run --project ./BuberDinner.Api
xdg-open http://localhost:5110/swagger/index.html

# # Extract the listening port from the output
# port=$(echo "$output" | grep -oP "Now listening on: http://localhost:\K\d+")

# # Check if a valid port is found
# if [[ -n "$port" ]]; then
#   # Launch the browser with the localhost URL
#   xdg-open "http://localhost:$port"
# else
#   echo "Failed to determine the listening port."
# fi
